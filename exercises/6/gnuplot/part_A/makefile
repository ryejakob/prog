all: gam.svg er.svg

gam.svg: gam.gpi out_gam.txt
	gnuplot $<

out_gam.txt: main_gam.exe
	mono $< > $@

main_gam.exe: main_gam.cs fun.dll 
	mcs -reference:fun.dll -out:$@ $<

er.svg: er.gpi out_er.txt
	gnuplot $<

out_er.txt: main_er.exe
	mono $< > $@

main_er.exe: main_er.cs fun.dll 
	mcs -reference:fun.dll -out:$@ $<

fun.dll: fun.cs
	mcs -target:library -out:$@ $^

.PHONY:clean
clean:
	rm -f lib/*.dll  math.dll *.exe out.*.txt *.dat *.svg
