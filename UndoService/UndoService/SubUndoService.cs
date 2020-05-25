﻿// Copyright (c) Peter Dongan. All rights reserved.
// Licensed under the MIT licence. https://opensource.org/licenses/MIT
// Project: https://github.com/peterdongan/UndoService

using System;

namespace StateManagement 
{
    /// <summary>
    /// This is used to track changes to a particular section of the application. It is used in conjunction with AggregateUndoService.
    /// </summary>
    public class SubUndoService : IStateRecorder
    {
        private readonly IUndoService _undoService;

        internal SubUndoService(IUndoService undoService)
        {
            _undoService = undoService;

            _undoService.StateRecorded += UndoService_StateRecorded;
        }

        public event StateRecordedEventHandler StateRecorded;

        public event StateSetEventHandler StateSet
        {
            add
            {
                _undoService.StateSet += value;
            }
            remove
            {
                _undoService.StateSet -= value;
            }
        }

        /// <summary>
        /// This is used by the AggregateUndoService to keep track of where changes were made.
        /// </summary>
        internal int Index { get; set; }

        internal bool CanUndo => _undoService.CanUndo;

        internal bool CanRedo => _undoService.CanRedo;

        public static SubUndoService CreateSubUndoService<T>(GetState<T> getState, SetState<T> setState, int? cap)
        {
            return new SubUndoService(new UndoService<T>(getState, setState, cap));
        }

        public void RecordState() => _undoService.RecordState();

        internal void ClearStacks() => _undoService.ClearStacks();

        internal void ClearUndoStack() => _undoService.ClearUndoStack();

        internal void Undo() => _undoService.Undo();

        internal void Redo() => _undoService.Redo();

        private void UndoService_StateRecorded(object sender, EventArgs e)
        {
            StateRecorded?.Invoke(this, new EventArgs());
        }
    }
}
