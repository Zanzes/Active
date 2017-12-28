#pragma once
#include <qt/qapplication.h>

class QInitializer
{
	QApplication applictaion_;
public:
	QInitializer(int argc, char* argv[]) : applictaion_(argc, argv) {}
	void pre();
	void main();
	void post();
	inline int exec()
	{
		main();
		const int r =applictaion_.exec();
		post();
		return r;
	}
};

