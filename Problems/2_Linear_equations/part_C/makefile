all: outC.txt

outC.txt : main.exe 
	mono main.exe > outC.txt

main.exe : main.cs gi_rot.dll matrix.dll vector.dll gram_s.dll RandMatrix.dll
	mcs -reference:gi_rot.dll -reference:matrix.dll -reference:vector.dll -reference:gram_s.dll -reference:RandMatrix.dll main.cs

gi_rot.dll: gi_rot.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

gram_s.dll: gram_s.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

RandMatrix.dll: RandMatrix.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

test.dll: test.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe *.txt *.svg 
