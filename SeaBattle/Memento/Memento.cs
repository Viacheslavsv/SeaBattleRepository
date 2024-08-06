using SeaBattle.Models;


namespace SeaBattle.Memento
{
    public class Memento
    {
        public Field MyField { get; }
        public Field EnemyField { get; }
        public Memento(Field myField, Field enemyField)
        {
            MyField = (Field)myField.Clone();
            EnemyField = (Field)enemyField.Clone();
        }
    }
}
