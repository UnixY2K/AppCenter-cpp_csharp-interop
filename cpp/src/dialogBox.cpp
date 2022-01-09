#include <dialogBox.hpp>
#ifdef _WIN32
// windows message box
#include <windows.h>
#endif
// for linux we use gtkmm 3.0
#ifdef __linux__
#include <gtkmm/messagedialog.h>
#endif

void showDialogBox(std::string title, std::string message) {
// windows message box
#ifdef _WIN32
    MessageBox(NULL, message.c_str(), title.c_str(), MB_OK);
#endif
// linux message box
#ifdef __linux__
    auto app = Gtk::Application::create("com.example.myapp");
	Gtk::MessageDialog dialog(title, false, Gtk::MESSAGE_INFO);
    dialog.set_secondary_text(message);
    // close the dialog when the user clicks the OK button
    dialog.signal_response().connect([&dialog, &app](int) {
        // close the dialog
        dialog.close();
        // exit the application
        app->quit();
    });
    app->run(dialog);
#endif
}