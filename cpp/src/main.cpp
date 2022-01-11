#include <AppCenter.hpp>
#include <dialogBox.hpp>
#include <iostream>

#ifndef APPCENTER_APP_SECRET
#define APPCENTER_APP_SECRET ""
#endif

#define myAppLIBRARY_EXPORT
#include <exportAPI.hpp>

// your main code
int main() {
	std::cout << "C++ Powered\n";
	Interop::AppCenter::trackEvent("[Native][Init]", {{"Hello", "from C++"}});
	showDialogBox("C++ Powered", "Hello from C++!");
}
// the entry point of your program
// you need to export this function

extern "C" {
myAppAPI void dllEntry() { main(); }
// this will setup the callbacks needed by the C++ code
// in order to call the AppCenter.trackEvent() function
myAppAPI void setupAppCenterCallbacks(
    void (*trackEventCallback)(const char *str),
    void (*trackEventExtraCallback)(const char *str, const char *data)) {
	Interop::AppCenter::setTrackEventCallback(trackEventCallback);
	Interop::AppCenter::setTrackEventCallback(trackEventExtraCallback);
}
// this will retrieve the AppCenter app secret
myAppAPI const char* getAppCenterAppSecret() {
	constexpr const char *appSecret = APPCENTER_APP_SECRET;
	return appSecret;
}
}
