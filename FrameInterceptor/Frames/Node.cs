using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor.Frames
{
    public class Node : IEnumerable
    {
        private int _index = -1;
        private int _level = 0;
        private string _value = null;
        private List<Node> _nodes = new List<Node>();
        private Node _parent;
        private Node _current;
        private Node _root;
        private NodeCoordinates _coods;


        public Node() 
        {
            this._root = this;
        }

        public Node(string iData, char[] separators, Node iParent = null ,int iLevel = 0, int sIndex = 0)
        {
            if (iParent == null)
            {
                this._root = this;
            }
            else
            {
                this._root = iParent._root;
            }

            this._level = iLevel;
            this._parent = iParent;
            string[] parts = new string[] { iData };
            this._current = this;
            this._coods = this.SetCoordinates(this);

            int tmpIndex = sIndex;

            while (tmpIndex < separators.Length && parts.Length < 2)
            {
                parts = iData.Split(separators[tmpIndex]);

                tmpIndex++;
            }

            if (parts.Length > 0)
            {
                if (parts.Length == 1)
                {
                    this._value = parts[0];
                }
                else
                {
                    iLevel++;
                    sIndex++;
                    foreach (string p in parts)
                    {
                        this._nodes.Add(new Node(p, separators, this, iLevel, sIndex));
                    }
                }
            }
        }

        #region Public Members
        public void Add(Node node)
        {
            this._nodes.Add(node);
        }

        public void Remove(Node node)
        {
            this._nodes.Remove(node);
        }

        public void Remove()
        {
            this._nodes.Remove(this);
        }

        public Node GetNode(NodeCoordinates iCords, int iPosition = 0)
        {
            Node node = new Node();
            NodeCoordinates coords = iCords;
            int idx = iPosition;

            if (idx < coords.Length)
            {
                if (this.Length <= iCords[idx])
                {
                    return null;
                }

                node = this[coords[idx]];

                return node.GetNode(coords, ++idx);
            }

            return this;
        }

        public Node GetNodeFromRoot(NodeCoordinates iCords)
        {
            return this._root.GetNode(iCords);
        }

        public Node CombineWith(Node node)
        {
            this._value += node.Value;

            return this;
        }

        public Node Append(string iValue)
        {
            this._value += iValue;

            return this;
        }

        public Node Prepend(string iValue)
        {
            this._value = iValue + this._value;

            return this;
        }

        public NodeEnumerator GetEnumerator()
        {
            return new NodeEnumerator(this._nodes);
        }
        #endregion

        #region Private Members

        private NodeCoordinates SetCoordinates(Node node)
        {
            int[] l_Coords = new int[node.Level];

            Node l_Node = node;

            while (l_Node != node.Root)
            {
                int l_Index = 0;

                if (l_Node.Parent != null && l_Node.Parent.HasChildren)
                    l_Index = l_Node.Parent.LastChild.Index + 1;

                l_Coords[l_Node.Level - 1] = l_Index;

                l_Node = l_Node.Parent;
            }

            return new NodeCoordinates(l_Coords);
        }

        private Node NextSiblingInternal()
        {
            Node l_Node = (this._parent == null) ? this._root : this._parent;

            if (this.Index == -1)
                return null;

            if (this.Index >= l_Node.Length - 1)
                return null;

            return l_Node.Nodes[this.Index + 1];
        }

        private Node PreviousSiblingInternal()
        {
            Node l_Node = (this._parent == null) ? this._root : this._parent;

            if (this.Index <= 0)
                return null;

            return l_Node.Nodes[this.Index - 1];
        }

        private Node NextInternal(Node iNode = null)
        {
            Node l_Node = (iNode == null) ? this : iNode;

            if (l_Node.IsRoot)
            {
                if (l_Node.HasChildren)
                    return l_Node.FirstChild;

                return null;
            }


            if (l_Node.IsLastChild && !l_Node.HasChildren)
            {
                Node l_Iterator = l_Node;

                while (l_Node.Parent.NextSibling == null)
                {
                    if (l_Node.Parent.IsRoot)
                        return null;

                    l_Node = l_Node.Parent;
                }

                if (l_Node.Parent.NextSibling != null)
                    return l_Node.Parent.NextSibling;
            }

            if (l_Node.HasChildren)
                return l_Node.FirstChild;

            return l_Node.NextSibling;
        }

        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {

            return (IEnumerator)GetEnumerator();
        }

        public Node this[int a] { get => this._nodes[a]; }

        public static implicit operator string(Node n)
        {
            if (n._value == null && n.Length > 0)
            {
                return n[0];
            }

            return n._value;
        }

        public int Level { get => this._level; }
        public string Value { get => this._value; set => this._value = value; }
        public List<Node> Nodes { get => this._nodes; }
        public List<Node> Children => Nodes;
        public int Length { get => this._nodes.Count; }
        public Node Parent { get => this._parent; }
        public Node Root { get => this._root; }
        public Node Current { get => this._current; }
        public int Index { get => (this.Parent == null) ? this._root.Nodes.IndexOf(this) : this._parent.Nodes.IndexOf(this); }
        public Node NextSibling { get => this.NextSiblingInternal(); }
        public Node PreviousSibling { get => this.PreviousSiblingInternal(); }
        public Node FirstChild { get => (this._nodes.Count > 0) ? this._nodes.First() : null; }
        public Node LastChild { get => (this._nodes.Count > 0) ? this._nodes.Last() : null; }
        public Node Next { get => this.NextInternal(); }
        public NodeCoordinates Coordinates { get => this._coods; }
        public NodeCoordinates Coords => Coordinates;
        public bool HasChildren { get => this._nodes.Count > 0; }
        public bool IsFirstChild { get => (this.Parent != null && object.ReferenceEquals(this, this.Parent.FirstChild)); }
        public bool IsLastChild { get => (this.Parent != null && object.ReferenceEquals(this, this.Parent.LastChild)); }
        public bool IsRoot { get => object.ReferenceEquals(this, this._root); }
    }

    public class NodeEnumerator : IEnumerator
    {
        private int _index = -1;
        public List<Node> Node;

        public NodeEnumerator(List<Node> array)
        {
            this.Node = array;
        }

        public bool MoveNext()
        {
            this._index++;
            return (this._index < this.Node.Count);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public Node Current
        {
            get
            {
                try
                {
                    return this.Node[this._index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        object IEnumerator.Current { get => Current; }
    }


    public class NodeCoordinates
    {
        private int[] _cords;

        public NodeCoordinates(int[] iCords)
        {
            this._cords = iCords;
        }

        public int this[int i] { get => this._cords[i]; }
        public int[] Cords { get => this._cords; }
        public int Length { get => this._cords.Length; }

        public static implicit operator NodeCoordinates(int[] n)
        {
            return new NodeCoordinates(n);
        }
    }
}
