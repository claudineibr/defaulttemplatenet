set /p NomeProjeto="Informe o nome do projeto:"
echo mkdir ProjetoPadrao > .\git_clone.sh
echo cd ProjetoPadrao >> git_clone.sh
echo git clone https://github.com/claudineibr/defaulttemplatenet.git . >> git_clone.sh

if exist "%SYSTEMDRIVE%\Program Files (x86)\Git\bin\sh.exe" (
	echo "32 bits"
	set GitEXE="%SYSTEMDRIVE%\Program Files (x86)\Git\bin\sh.exe"
) else if exist "%SYSTEMDRIVE%\Program Files\Git\bin\sh.exe" (
	echo "64 bits"
	set GitEXE="%SYSTEMDRIVE%\Program Files\Git\bin\sh.exe"
) else (
	echo "Git nao encontrado. Instale o GIT para utilizar."
	exit /b
)

%GitEXE% --login git_clone.sh
del git_clone.sh
copy .\ProjetoPadrao\criaProjeto.bat
cmd /C criaProjeto.bat %NomeProjeto%
del criaProjeto.bat