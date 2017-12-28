#include "QInitializer.h"
#include <QHooker.h>
#include <iostream>
#include <Windows.h>

QHooker q;

void bla(KeyboardData data)
{
	std::cout <<  data.Key << std::endl;
}

void QInitializer::pre()
{
}

void QInitializer::main()
{
	q.addEvent(bla);
	q.hook();
}

void QInitializer::post()
{
	q.unhook();
}
