#pragma once
#include <string>

namespace loadlib {
// Loads a library and returns a handle to it.
void *getFuncPtr(const char *library, const char *function);
} // namespace loadlib