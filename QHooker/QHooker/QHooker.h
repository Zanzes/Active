#pragma once
#include <Windows.h>
#include "KeyboardData.h"

class __declspec(dllexport) QHooker
{
	static void UpdateKey(BYTE* ks, int key);
	static void executeFuncs(KeyboardData str);
	static void executeFuncs();
	static LRESULT CALLBACK MyLowLevel(int nCode, WPARAM wparam, LPARAM lparam);
public:
	QHooker(){	}

	void hook();
	void addEvent(void(*todo)(KeyboardData));
	void addEvent(void(*todo)());
	void unhook() const;
};