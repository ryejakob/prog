all: out_part_1.txt out_part_2.txt

out_part_2.txt: main_2.exe
	mono main_2.exe > out_part_2.txt

main_2.exe : main_2.cs gram_s.dll matrix.dll vector.dll 
	mcs -reference:gram_s.dll -reference:matrix.dll -reference:vector.dll main_2.cs

out_part_1.txt : main.exe 
	mono main.exe > out_part_1.txt

main.exe : main.cs gram_s.dll matrix.dll vector.dll 
	mcs -reference:gram_s.dll -reference:matrix.dll -reference:vector.dll main.cs

gram_s.dll: gram_s.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

test.dll: test.cs
	mcs -target:library -out:$@ $<
