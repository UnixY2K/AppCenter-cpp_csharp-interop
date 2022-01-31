#include <loadLib.hpp>

#ifdef _WIN32
#include <windows.h>
#define symLoad GetProcAddress
#else
#include <dlfcn.h>
#define symLoad dlsym
#endif

namespace loadlib {
#ifdef _WIN32
using Handle = HINSTANCE;
#else
using Handle = void *;
#endif

// Loads a library and returns a handle to it.
void *getFuncPtr(const char *path, const char *funcName) {
#ifdef _WIN32
	HINSTANCE handle = LoadLibraryA(path);
#else
	Handle handle = dlopen(path, RTLD_LAZY);
#endif
	if (!handle) {
		return nullptr;
	}
	void *funcPtr = (void*)symLoad(handle, funcName);
	return funcPtr;
}
} // namespace loadlib