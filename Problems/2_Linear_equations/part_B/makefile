all: outB.txt

outB.txt : main.exe 
	mono main.exe > out.txt

main.exe : main.cs gram_s.dll matrix.dll vector.dll RandMatrix.dll
	mcs -reference:gram_s.dll -reference:matrix.dll -reference:vector.dll -reference:RandMatrix.dll main.cs

gram_s.dll: gram_s.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

RandMatrix.dll: RandMatrix.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe *.txt *.svg 
