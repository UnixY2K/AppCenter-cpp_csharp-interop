#include <iostream>
#include <loadLib.hpp>

// function pointer to the function we want to call
void (*initAppCenter)(const char *secret);

// your main code
int main() {
	std::string lib = "./DotNetLib";
#ifdef _WIN32
	lib += ".dll";
#else
	lib += ".so";
#endif
	initAppCenter = (void (*)(const char *))loadlib::getFuncPtr(
	    lib.c_str(), "APPCENTER_API_START");
	if (initAppCenter) {
		initAppCenter("C++");
	} else {
		std::cerr << "[C++/Native]Error loading library\n";
	}
}
