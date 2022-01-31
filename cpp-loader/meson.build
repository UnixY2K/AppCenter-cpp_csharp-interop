myApp_inc = include_directories('include')

myApp_sources = [
    'src/source.cpp',
    'src/loadLib.cpp',
]
myApp_args = []
myApp_link = []
myApp_deps = []

## platform depedencies

# check if is linux
if host_machine.system() == 'linux'
    message('Building for Linux')
    dl_dep = meson.get_compiler('cpp').find_library('dl')
    myApp_deps += [dl_dep]
endif

myApp_exe = executable('myApp',
                            myApp_sources,
                            include_directories: myApp_inc,
                            cpp_args: myApp_args,
                            dependencies: myApp_deps,
                            link_with: myApp_link)
