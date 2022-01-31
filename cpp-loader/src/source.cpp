#include <iostream>
#include <loadLib.hpp>

// function pointer to the function we want to call
void (*doGreet)(const char *);

// your main code
int main() {
	std::string lib = "./DotNetLib";
#ifdef _WIN32
	lib += ".dll";
#else
	lib += ".so";
#endif
	doGreet =
	    (void (*)(const char *))loadlib::getFuncPtr(lib.c_str(), "doGreet");
	if (doGreet) {
		doGreet("C++");
	} else {
		std::cerr << "[C++/Native]Error loading library" << std::endl;
	}
}
