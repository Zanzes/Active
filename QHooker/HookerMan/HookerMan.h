#pragma once
#include <Windows.h>
#include "KeyboardData.h"

ref class __declspec(dllexport) HookerMan
{
	static void UpdateKey(BYTE* ks, int key);
	static void executeFuncs(KeyboardData str);
	static void executeFuncs();
	static LRESULT CALLBACK my(int nCode, WPARAM wparam, LPARAM lparam);
public:
	HookerMan() {	}

	void hook();
	void addEvent(void(*todo)(KeyboardData));
	void addEvent(void(*todo)());
	void unhook();
};