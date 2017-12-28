#pragma once
#include "Node.h"

namespace LZSoft
{
	namespace DataStructures
	{
		template <class T>
		class LZLinkedList
		{
		private:
			int _count = 0;
			int _count64 = 0;
		public:
			Node<T> *Head = nullptr, *Tail = nullptr;
			const int &Count = _count;
			const int &Count64 = _count;
			void Add(const T value);
			void Remove(Node<T>* node);
			void RemoveHead();
			void RemoveTail();
			void RemoveAt(const int index);
			Node<T>* AtIndex(const int index);
			void RemoveAt64(const int index);
			Node<T>* AtIndex64(const int index);
			LZLinkedList();
			LZLinkedList(const LZLinkedList<T>& source);
			LZLinkedList<T>& operator = (const LZLinkedList<T>& right);
			
		};

		#include "LZLinkedList.inl"
	}
}
