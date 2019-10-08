// CalculatorDLL.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"

#include "CalculatorDLL.h"

int _stdcall add_int(int a, int b)
{
	return a + b;
}

double _stdcall add_double(double a, double b)
{
	return a + b;
}

int _stdcall sub_int(int a, int b)
{
	return a - b;
}

double _stdcall sub_double(double a, double b)
{
	return a - b;
}

int _stdcall mult_int(int a, int b)
{
	return a * b;
}

double _stdcall mult_double(double a, double b)
{
	return a * b;
}

int _stdcall div_int(int a, int b)
{
	return a / b;
}

double _stdcall div_double(double a, double b)
{
	return a / b;
}


