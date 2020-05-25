﻿// Copyright (c) Peter Dongan. All rights reserved.
// Licensed under the MIT licence. https://opensource.org/licenses/MIT
// Project: https://github.com/peterdongan/UndoService

namespace StateManagement
{
    /// <summary>
    /// Performs Undo/redo actions.
    /// </summary>
    public interface IUndoRedo
    {

        bool CanUndo { get; }

        bool CanRedo { get; }

        /// <summary>
        /// Clear the Undo and Redo stacks.
        /// </summary>
        void ClearStacks();

        void ClearUndoStack();

        void Undo();

        void Redo();
    }
}
