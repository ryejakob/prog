out.txt : main.exe 
	mono main.exe > out.txt

main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

#LIBDIR = /prog/libra
#cmath.dll : $(LIBDIR)/cmath.cs $(LIBDIR)/complex.cs
#	mcs -target:library -out:cmath.dll $^

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

clean:
	rm -f out.txt main.exe
