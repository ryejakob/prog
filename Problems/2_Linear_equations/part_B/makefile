all: out.txt

out.txt : main.exe 
	mono main.exe > out.txt

main.exe : main.cs gram_s.dll matrix.dll vector.dll 
	mcs -reference:gram_s.dll -reference:matrix.dll -reference:vector.dll main.cs

gram_s.dll: gram_s.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<
