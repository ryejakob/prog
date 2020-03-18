all: plot.svg

plot.svg: plot.gpi out.txt
	gnuplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs fun.dll 
	mcs -reference:fun.dll -out:$@ $<

fun.dll: fun.cs
	mcs -target:library -out:$@ $^

.PHONY:clean
clean:
	rm -f lib/*.dll  math.dll *.exe out.*.txt *.dat *.svg
