export WINCC=x86_64-w64-mingw32-gcc

# create .pre file (.h reference)
ls work/nuklear.pre && cp work/nuklear.pre work/nuklear.pre.old
$WINCC -E -P nuklear_options.h | sed -n '/./,/^$/p' >work/nuklear.pre
ls work/nuklear.pre.old && echo 'Diff between old nuklear.pre and new nuklear.pre:' && diff work/nuklear.pre.old work/nuklear.pre && echo End diff

# compile shared lib
$WINCC -Os -shared -fpic work/nuklear_impl.c -o ../native/win-x64/nuklear.dll

