# create .pre file (.h reference)
clang -E -P nuklear_h.h | sed -n '/./,/^$/p' >nuklear_h.pre
# (gcc fine too)

# compile shared lib
clang -shared -fpic nuklear_impl.c -o libnuklear.dylib
# (gcc linux, visual studio win: ehhhh)

