//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

namespace Hostile
{
    namespace Core
    {


        /*
         * List of Listablebehaviours
         */
        public class ComponentList
        {
            private ListableComponent _head = null; /// head of the list
            private ListableComponent _tail = null; /// tail of the list
            private int _count; /// number of items in the list

            public ListableComponent Head { get { return _head; } }
            public ListableComponent Tail { get { return _tail; } }

            public int Count
            {
                get
                {
                    return _count;
                }
            }

            public bool isEmpty
            {
                get
                {
                    return _head == null && _tail == null && _count == 0;
                }
            }

            public ComponentList()
            {
            }

            /*
             * @brief Insert an ListableBehaviour at the head of the list
             */
            private void InsertAtHead(ref ListableComponent item)
            {
                if (_head == null && _tail == null)
                {
                    _head = _tail = item;

					item.list = this;

                    _count++;
                    return;
                }
                InsertBefore(ref _head, ref item);
                _head = item;
            }

            /*
             * @brief Insert an GameObject at the head of the list
             */
            public void InsertAtHead(ref GameObject obj)
            {
                ListableComponent listable = obj.GetComponent<ListableComponent>();
                InsertAtHead(ref listable);
            }

            /*
             * @brief Insert an ListableBehaviour at the tail of the list
             */
            private void InsertAtTail(ref ListableComponent item)
            {
                if (_head == null && _tail == null)
                {
                    _head = _tail = item;
					item.list = this;
					_count++;
                    return;
                }
                InsertAfter(ref _tail, ref item);
                _tail = item;
            }

            /*
             * @brief Insert an GameObject at the tail of the list
             */
            public void InsertAtTail(ref GameObject obj)
            {
                ListableComponent listable = obj.GetComponent<ListableComponent>();
                InsertAtTail(ref listable);
            }

            private ListableComponent RemoveHead()
            {
                if (_head)
                {
                    ListableComponent head = _head;
                    //_head = _head.Next;
                    Remove(ref head);
                    if (_head == null)
                        _tail = null;
                    return head;
                }
                return null;
            }

            public GameObject RemoveHeadGO()
            {
                ListableComponent head = RemoveHead();
                return (head)? head.gameObject:null;
            }

            private ListableComponent RemoveTail()
            {
                if (_tail)
                {
                    ListableComponent tail = _tail;
                    //_tail = _tail.Previous;
                    Remove(ref tail);
                    if (_tail == null)
                        _head = null;
                    return tail;
                }
                return null;
            }

            public GameObject RemoveTailGO()
            {
                ListableComponent tail = RemoveTail();
                return (tail) ? tail.gameObject : null;
            }

            private static void ClearLink(ref ListableComponent node)
            {
                node.Previous = node.Next = null;
            }
            private static void Unlink(ref ListableComponent node)
            {
                if (node.Previous != null)
                    node.Previous.Next = node.Next;
                if (node.Next != null)
                    node.Next.Previous = node.Previous;

				
				node.list = null;

                ClearLink(ref node);
            }

            private void InsertAfter(ref ListableComponent target, ref ListableComponent item)
            {
                if (item == null)
                    return;

                //Unlink(ref item);

                item.Next = target.Next;
                item.Previous = target;
                if (target.Next)
                    target.Next.Previous = item;
                target.Next = item;
                _count++;

				item.list = this;

            }

            private void InsertBefore(ref ListableComponent target, ref ListableComponent item)
            {
                if (item == null)
                    return;

                //Unlink(ref item);

                item.Next = target;
                item.Previous = target.Previous;
                if (target.Previous)
                    target.Previous.Next = item;
                target.Previous = item;
                _count++;

				
				item.list = this;
            }

            private void Remove(ref ListableComponent target)
            {
                if (target == _head)
                {
                    _head = _head.Next;
                }
                if (target == _tail)
                {
                    _tail = _tail.Previous;
                }
                Unlink(ref target);
                _count--;
            }

            public void Remove(GameObject obj)
            {
                ListableComponent listable = obj.GetComponent<ListableComponent>();
                Remove(ref listable);
            }
        }
    }

}