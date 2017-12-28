#pragma once
template <class T>
void LZLinkedList<T>::Add(const T value)
{
	Node<T> *n = new Node<T>;
	n->value = value;
	if (Count == 0)
	{
		Head = n;
		Tail = n;
		n = nullptr;
	}
	else
	{
		n->previous = Head;
		Head->next = n;
		Head = n;
	}
	_count++;
}

template <class T>
void LZLinkedList<T>::Remove(Node<T>* node)
{
	Node<T>* n = Head;
	for (int i = 0; i < Count; i++)
		if (n == node)
		{
			Node<T>* p = n->previous;
			p->next = n->next;
			n->next->previous = p;
		}
		else
			n = n->previous;
	_count--;
}

template <class T>
void LZLinkedList<T>::RemoveHead()
{
	if (_count == 1)
	{
		Head = nullptr;
		Tail = nullptr;
		_count--;
		return;
	}
	Head = Head->previous;
	Head->next = nullptr;
	_count--;
}

template <class T>
void LZLinkedList<T>::RemoveTail()
{
	if (_count == 1)
	{
		Head = nullptr;
		Tail = nullptr;
		_count--;
		return;
	}
	Tail = Tail->next;
	Tail->previous = nullptr;
	_count--;
}

template <class T>
void LZLinkedList<T>::RemoveAt(const int index)
{
	Node<T>* n = Tail;
	for (int i = 0; i <= index; i++)
	{
		if (i == index)
		{
			Node<T>* p = n->previous;
			p->next = n->next;
			p->next->previous = p;
			//n->previous->next = n->next->next;
		}
		else
			n = n->next;
	}
	_count--;
}

template <class T>
void LZLinkedList<T>::RemoveAt64(const int index)
{
	Node<T>* n = Tail;
	for (int i = 0; i <= index; i++)
	{
		if (i == index)
		{
			Node<T>* p = n->previous;
			p->next = n->next;
			p->next->previous = p;
			//n->previous->next = n->next->next;
		}
		else
			n = n->next;
	}
	_count64--;
}

template <class T>
Node<T>* LZLinkedList<T>::AtIndex(const int index)
{
	Node<T>* n = Tail;
	for (int i = 0; i <= index; i++)
	{
		if (i == index)
			return n;
		n = n->next;
	}
	return nullptr;
}

template <class T>
Node<T>* LZLinkedList<T>::AtIndex64(const int index)
{
	Node<T>* n = Tail;
	for (int i = 0; i <= index; i++)
	{
		if (i == index)
			return n;
		n = n->next;
	}
	return nullptr;
}

template <class T>
LZLinkedList<T>::LZLinkedList()
{
}

template <class T>
LZLinkedList<T>::LZLinkedList(const LZLinkedList& source)
{
	Head = source.Head;
	Tail = source.Tail;
	_count = source._count;
}

template <class T>
LZLinkedList<T>& LZLinkedList<T>::operator=(const LZLinkedList<T>& right)
{
	Head = right.Head;
	Tail = right.Tail;
	_count = right._count;
	return *this;
}