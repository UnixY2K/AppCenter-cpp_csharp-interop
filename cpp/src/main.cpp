#include <dialogBox.hpp>
#include <iostream>

#define myAppLIBRARY_EXPORT
#include <exportAPI.hpp>

// your main code
int main() {
	std::cout << "C++ Powered\n";
	showDialogBox("C++ Powered", "Hello from C++!");
}
// the entry point of your program
// you need to export this function

extern "C" {
myAppAPI void dllEntry() { main(); }
}
