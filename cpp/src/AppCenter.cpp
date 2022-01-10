#include <AppCenter.hpp>
#include <iostream>

namespace Interop {
namespace AppCenter {
void (*trackEventCallback)(const char *str) = nullptr;
void (*trackEventExtraCallback)(const char *str, const char *data) = nullptr;

void setTrackEventCallback(void (*callback)(const char *str)) {
	trackEventCallback = callback;
}
void setTrackEventCallback(void (*callback)(const char *str,
                                            const char *data)) {
	trackEventExtraCallback = callback;
}

void trackEvent(std::string event) {
	if (trackEventCallback) {
		trackEventCallback(event.c_str());
	} else {
		std::cerr << "Interop::AppCenter::trackEventCallback is nullptr\n";
	}
}

void trackEvent(std::string event, Properties properties) {
	if (trackEventExtraCallback) {
		trackEventExtraCallback(event.c_str(), toJson(properties).c_str());
	} else {
		std::cerr << "Interop::AppCenter::trackEventExtraCallback is nullptr\n";
	}
}

} // namespace AppCenter
} // namespace Interop