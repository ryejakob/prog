all: outA.txt

outA.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs integrator.dll vector.dll
	mcs -reference:integrator.dll -reference:vector.dll main.cs

integrator.dll: integrator.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

clean: ; $(RM) *.dll *.exe *.txt *.svg 
