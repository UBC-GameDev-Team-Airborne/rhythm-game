using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CustomBeatmapMaker.Action
{
    public class ActionManager
    {
        public ReadOnlyCollection<Action> UndoStack => _undoStack.ToList().AsReadOnly();
        private Stack<Action> _undoStack { get; set; }
        private Stack<Action> _redoStack { get; set; }

        public ActionManager()
        {
            _undoStack = new Stack<Action>();
            _redoStack = new Stack<Action>();
        }

        public void PerformNewAction(Action action)
        {
            _undoStack.Push(action);
            _redoStack.Clear();

            action.Perform();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0) return;

            Action action = _undoStack.Pop();
            action.Inverse.Perform();
            _redoStack.Push(action);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0) return;

            Action action = _redoStack.Pop();
            action.Perform();
            _undoStack.Push(action);
        }
    }
}