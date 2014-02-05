net stop WotTasker
sc delete WotTasker
sc create WotTasker binPath=WotTasker.exe start= auto
net start WotTasker