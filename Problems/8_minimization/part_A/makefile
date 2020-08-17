all: out.txt

out.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs vector.dll mini.dll
	mcs -reference:vector.dll -reference:mini.dll main.cs

mini.dll:mini.cs vector.dll matrix.dll
	mcs -reference:vector.dll -reference:matrix.dll -target:library -out:$@ $<

matrix.dll:matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe out.*.txt *.svg 
