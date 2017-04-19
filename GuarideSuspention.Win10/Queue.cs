using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuarideSuspention.Win10
{

        class Queue
        {
            public Queue Next { get; set; }
            public Person Value { get; set; }
            private Queue _head, _tail;

            public int Count { get; private set; }
            public void Push(Person value)
            {
                Queue n = new Queue { Value = value };
                if (_head == null)
                {
                    _head = n;
                    _tail = n;
                }
                else
                {
                    _tail.Next = n;
                    _tail = n;
                }
                Count++;
            }
            public Person Pull()
            {
                if (Count < 1)
                    throw new Exception("Очередь пустая!");

                Person tmp = _head.Value;
                _head = _head.Next;
                Count--;
                return tmp;

            }
        }
        class IsEmpty : Exception
        { }
    }


