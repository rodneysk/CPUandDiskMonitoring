# Monitoramento de Disco e CPU

Programinha feito em C# no qual irá registrar num arquivo .txt todas às vezes que o CPU ou Disco atingirem 100%.

Caso identicado algum registro, o arquivo será salvo no seguinte caminho: 
CPUandDiskMonitoring\Monitoramento\bin\Debug\registro.txt

Fiz o projeto baseado no CPU e nos dois discos da minha máquina (C e D). Caso você tenha apenas o disco C, se atentar nas seguintes alterações no arquivo 'Program.cs':

- Comentar à linha 34 'float diskPercentD = GetDiskUsage("D")';
- Remover o trecho '|| diskPercentD == 100' da linha 36;
- Remover o trecho ', Disco D: {diskPercentD}%' da linha 41;

Caso tenha alguma dúvida é só perguntar!
<div> 
  <a href="https://www.linkedin.com/in/rodneysk" target="_blank"><img height=25 width=75 src="https://img.shields.io/badge/-LinkedIn-%230077B5?style=for-the-badge&logo=linkedin&logoColor=white" target="_blank"></a> 
  <a href = "mailto:rodneysk@hotmail.com"><img height=25 width=100 src="https://img.shields.io/badge/Microsoft_Outlook-0078D4?style=for-the-badge&logo=microsoft-outlook&logoColor=white" target="_blank"></a>
   <a href="https://discord.com/users/Gotinha#6271" target="_blank"><img height=25 width=75 src="https://img.shields.io/badge/Discord-7289DA?style=for-the-badge&logo=discord&logoColor=white" target="_blank"></a> 
  <a href="https://instagram.com/rodneysk" target="_blank"><img height=25 width=75 src="https://img.shields.io/badge/-Instagram-%23E4405F?style=for-the-badge&logo=instagram&logoColor=white" target="_blank"></a>
</div>
