#pragma once
#include <utils.hpp>

namespace Interop {
namespace AppCenter {

void setTrackEventCallback(void (*callback)(const char *str));
void setTrackEventCallback(void (*callback)(const char *str, const char *data));

void trackEvent(std::string event);
void trackEvent(std::string event, Properties properties);

} // namespace AppCenter
} // namespace Interop
