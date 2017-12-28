#include "KeyboardData.h"


KeyboardData::KeyboardData(): Key(nullptr), interpreted(0), vkCode(0), scanCode(0), flags(0), time(0), dwExtraInfo(0)
{
}

KeyboardData::KeyboardData(KBDLLHOOKSTRUCT data)
{
	copyData(data);
}

void KeyboardData::copyData(KBDLLHOOKSTRUCT data)
{
	vkCode = data.vkCode;
	scanCode = data.scanCode;
	flags = data.flags;
	time = data.time;
	dwExtraInfo = data.dwExtraInfo;
}


KeyboardData::~KeyboardData()
{
}
