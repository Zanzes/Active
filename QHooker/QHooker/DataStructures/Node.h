#pragma once
namespace LZSoft
{
	namespace DataStructures
	{
		template <class T>
		struct Node
		{
			Node(){};
			T value;
			Node<T> *next;
			Node<T> *previous;
		};
	}
}