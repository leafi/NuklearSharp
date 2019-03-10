# create .pre file (.h reference)
ls work/nuklear.pre && cp work/nuklear.pre work/nuklear.pre.old
# (gcc fine too)
clang -E -P nuklear_options.h | sed -n '/./,/^$/p' >work/nuklear.pre
ls work/nuklear.pre.old && echo 'Diff between old nuklear.pre and new nuklear.pre:' && diff work/nuklear.pre.old work/nuklear.pre && echo End diff

# compile shared lib
clang -shared -fpic work/nuklear_impl.c -o ../native/linux-x64/libnuklear.so

