all: out.txt

out.txt : main.exe 
	mono main.exe > out.txt

main.exe : main.cs gi_rot.dll matrix.dll vector.dll 
	mcs -reference:gi_rot.dll -reference:matrix.dll -reference:vector.dll main.cs

gi_rot.dll: gi_rot.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

test.dll: test.cs
	mcs -target:library -out:$@ $<
