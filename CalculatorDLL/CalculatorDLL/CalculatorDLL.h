#pragma once
extern "C" _declspec(dllexport) int _stdcall add_int(int a, int b);
extern "C" _declspec(dllexport) double _stdcall add_double(double a, double b);

extern "C" _declspec(dllexport) int _stdcall sub_int(int a, int b);
extern "C" _declspec(dllexport) double _stdcall sub_double(double a, double b);

extern "C" _declspec(dllexport) int _stdcall mult_int(int a, int b);
extern "C" _declspec(dllexport) double _stdcall mult_double(double a, double b);

extern "C" _declspec(dllexport) int _stdcall div_int(int a, int b);
extern "C" _declspec(dllexport) double _stdcall div_double(double a, double b);