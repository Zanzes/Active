#pragma once
#include <Windows.h>

class __declspec(dllexport) KeyboardData
{
public:
	char* Key;
	int   interpreted;
	DWORD   vkCode;
	DWORD   scanCode;
	DWORD   flags;
	DWORD   time;
	ULONG_PTR dwExtraInfo;
	KeyboardData();
	KeyboardData(KBDLLHOOKSTRUCT data);
	~KeyboardData();
	void copyData(KBDLLHOOKSTRUCT data);
};

