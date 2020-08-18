out.txt: main.exe
	mono $< > $@

main.exe: main.cs vector3d.dll
	mcs main.cs -reference:vector3d.dll

vector3d.dll: ivector3d.cs vector3d.cs ivector3dfunctions.cs
	mcs $^ -target:library -out:$@

clean:
	rm -f *.dll *.exe out*

