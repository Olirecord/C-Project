using System;

namespace src
{
    internal class Terminal
    {
        public Terminal()
        {
        }

        public void printStatement(params string[] statements)
        {
            foreach (string statement in statements)
            {
                Console.WriteLine(statement);
            }

        }

        public string returnStatement()
        {
            return Console.ReadLine();
        }
    }
}