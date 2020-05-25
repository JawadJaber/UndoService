﻿// Copyright (c) Peter Dongan. All rights reserved.
// Licensed under the MIT licence. https://opensource.org/licenses/MIT
// Project: https://github.com/peterdongan/UndoService

using StateManagement.DataStructures;
using System;
using System.Collections.Generic;

namespace StateManagement
{
    /// <summary>
    /// Provides a unified Undo/Redo interface for multiple UndoServices.
    /// Change tracking is still done by the individual child SubUndoServices. Undo/Redo is done via this class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AggregateUndoService : IUndoService
    {
        private readonly SubUndoService[] _subUndoServices;
        private readonly IStack<int> _undoStack;
        private readonly Stack<int> _redoStack;
        private readonly UndoServiceValidator<int> _undoServiceValidator;

        public event StateSetEventHandler StateSet;
        public event StateRecordedEventHandler StateRecorded;

        public AggregateUndoService(SubUndoService[] subUndoServices)
        {
            _subUndoServices = subUndoServices ?? throw new ArgumentNullException(nameof(subUndoServices));
            
            _undoStack = new StackWrapper<int>();
            _redoStack = new Stack<int>();

            for (var i = 0; i < _subUndoServices.Length; i++)
            {
                _subUndoServices[i].StateRecorded += Subservice_StateRecorded;
                _subUndoServices[i].Index = i;
            }

            _undoServiceValidator = new UndoServiceValidator<int>(_undoStack, _redoStack);
        }



        public bool CanUndo => _undoServiceValidator.CanUndo;

        public bool CanRedo => _undoServiceValidator.CanRedo;

        public void ClearStacks()
        {
            _undoStack.Clear();
            _redoStack.Clear();
            foreach (var s in _subUndoServices)
            {
                s.ClearStacks();
            }
        }

        public void Undo()
        {
            _undoServiceValidator.ValidateUndo();

            var lastService = _undoStack.Pop();
            _subUndoServices[lastService].Undo();
            _redoStack.Push(lastService);

            //Check if the next SubUndoService has become empty. If it has, then empty all undo stacks.
            if (_undoStack.Count > 0)
            {
                var nextService = _undoStack.Peek();
                if (!_subUndoServices[nextService].CanUndo)
                {
                    ClearUndoStack();
                }
            }
            StateSet?.Invoke(this, new EventArgs());
        }

        public void Redo()
        {
            _undoServiceValidator.ValidateRedo();

            var lastService = _redoStack.Pop();
            _subUndoServices[lastService].Redo();
            _undoStack.Push(lastService);
            StateSet?.Invoke(this, new EventArgs());
        }

        private void Subservice_StateRecorded(object sender, EventArgs e)
        {
            var serviceId = ((SubUndoService)sender).Index;
            _undoStack.Push(serviceId);
            StateRecorded?.Invoke(this, new EventArgs());
        }

        public void ClearUndoStack()
        {
            _undoStack.Clear();
            foreach (var s in _subUndoServices)
            {
                s.ClearUndoStack();
            }
        }

        public void RecordState()
        {
            throw new Exception("State should be recorded in the SubUndoServices, not in the aggregate service itself");
        }
    }
}
