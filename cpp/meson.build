myApp_inc = include_directories('include')

myApp_sources = [
    'src/main.cpp',
    'src/dialogBox.cpp',
]
myApp_args = []
myApp_link = []
myApp_deps = []


if host_machine.system() == 'linux'
    message('Building for Linux')
    gtkmm_dep = dependency('gtkmm-3.0')
    myApp_deps += [gtkmm_dep]
endif


# we compile the c++ application as a shared library
myApp_lib = library('myapp',
                        myApp_sources,
                        include_directories : myApp_inc,
                        cpp_args: myApp_args,
                        dependencies : myApp_deps)

# we compile the c++ application as a standalone executable
# for development/debugging purposes
myApp_exe = executable('myApp',
                            myApp_sources,
                            include_directories: myApp_inc,
                            cpp_args: myApp_args,
                            dependencies: myApp_deps,
                            link_with: myApp_link)
