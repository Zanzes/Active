#include "QHooker.h"
#include <QtCore/QDebug>
#include <Windows.h>
#include <DataStructures/LZLinkedList.h>

using LZSoft::DataStructures::LZLinkedList;

LZLinkedList<void(*)(KeyboardData)> dataList;
LZLinkedList<void(*)()> voidList;
HHOOK hhook;

void QHooker::UpdateKey(BYTE* ks, int key)
{
	ks[key] = GetKeyState(key);
}

void QHooker::executeFuncs(const KeyboardData str)
{
	auto n = dataList.Head;
	for (int i = 0; i < dataList.Count; i++)
	{
		try
		{
			n->value(str);
		}
		catch (...)
		{
		}
		n = n->previous;
	}
}

void QHooker::executeFuncs()
{
	auto n = voidList.Head;
	for (int i = 0; i < voidList.Count; i++)
	{
		try
		{
			n->value();
		}
		catch (...)
		{
		}
		n = n->previous;
	}
}

LRESULT CALLBACK QHooker::MyLowLevel(int nCode, WPARAM wparam, LPARAM lparam)
{

	if (nCode < 0)
		return CallNextHookEx(hhook, nCode, wparam, lparam);

	const KBDLLHOOKSTRUCT kbst = *((KBDLLHOOKSTRUCT*)lparam);

	/*qDebug() << "Key: " << kbst.vkCode;
	qDebug() << "flags: " << kbst.flags;
	qDebug() << "code: " << kbst.scanCode;
	qDebug() << "time: " << kbst.time;
	qDebug();*/

	// Action
	//wchar_t buffer[5];
	BYTE kstate[256];

	GetKeyboardState(kstate);
	UpdateKey(kstate, VK_SHIFT);
	UpdateKey(kstate, VK_CAPITAL);
	UpdateKey(kstate, VK_CONTROL);
	UpdateKey(kstate, VK_MENU);

	HKL layout = GetKeyboardLayout(0);
	char lName[0x100] = { 0 };
	DWORD dwMsg = 1;
	dwMsg += kbst.scanCode << 16;
	dwMsg += kbst.flags << 24;
	int i = GetKeyNameText(dwMsg, (LPTSTR)lName, 255);

	KeyboardData data(kbst);
	data.Key = lName;
	data.interpreted = i;
	executeFuncs(data);
	executeFuncs();

	return CallNextHookEx(hhook, nCode, wparam, lparam);

}

void QHooker::hook()
{
	hhook = SetWindowsHookEx(WH_KEYBOARD_LL, MyLowLevel, NULL, 0);
}

void QHooker::addEvent(void(* todo)(KeyboardData))
{
	dataList.Add(todo);
}

void QHooker::addEvent(void(*todo)())
{
	voidList.Add(todo);
}

void QHooker::unhook() const
{
	UnhookWindowsHookEx(hhook);
}
