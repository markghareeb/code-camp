using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        public LinkedList<(int x, int y)> Body;
        public LinkedListNode<(int x, int y)> Head;
        public LinkedListNode<(int x, int y)> Tail;
        public Direction Direction; 

        public Snake((int x, int y) startingPosition, int length)
        {
            Body = new LinkedList<(int x, int y)>();
            Body.AddLast((startingPosition.x, startingPosition.y));
            
            for (int i = 1; i < length; i++)
            {
                Body.AddLast((startingPosition.x, startingPosition.y - i));
            }

            Head = Body.First;
            Tail = Body.Last;
            Direction = Direction.Right;
        }

        public bool IsHere((int x, int y) position)
        {
            return Body.Find(position) != null;
        }

        public bool IsHead((int x, int y) position)
        {
            return Head.Value == position;
        }

        public bool IsTail((int x, int y) position)
        {
            return Tail.Value == position;
        }

        public void Move()
        {
            Head = Body.AddFirst(CalculateNewHead());
            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
            }
            Body.RemoveLast();
        }

        public void UpdateDirection(ConsoleKeyInfo keyPressed)
        {
            if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                Direction = Direction.Up;
            }
            else if (keyPressed.Key == ConsoleKey.RightArrow)
            {
                Direction = Direction.Right;
            }
            else if (keyPressed.Key == ConsoleKey.DownArrow)
            {
                Direction = Direction.Down;
            }
            else if(keyPressed.Key == ConsoleKey.LeftArrow)
            {
                Direction = Direction.Left;
            }
        }

        private (int x, int y) CalculateNewHead()
        {
            (int x, int y) newHeadPosition;
            if (Direction == Direction.Up)
            {
                newHeadPosition = (Head.Value.x - 1, Head.Value.y);
            } 
            else if (Direction == Direction.Right)
            {
                newHeadPosition = (Head.Value.x, Head.Value.y + 1);
            }
            else if (Direction == Direction.Down)
            {
                newHeadPosition = (Head.Value.x + 1, Head.Value.y);
            }
            else
            {
                newHeadPosition = (Head.Value.x, Head.Value.y - 1);
            }
            return newHeadPosition;
        }
    }

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
}
