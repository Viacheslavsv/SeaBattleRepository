namespace SeaBattle.Memento
{
    public class Caretaker
    {
        private Stack<Memento> memento;
        public Caretaker()
        {
            memento = new Stack<Memento>();
        }
        public void AddMemento(Memento m)
        {
            memento.Push(m);
        }
        public Memento PickMemento()
        {
            if (memento.Count == 0)
                throw new NullReferenceException("Stack is empty");
            return memento.Pop();
        }
    }
}
