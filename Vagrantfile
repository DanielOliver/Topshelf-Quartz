Vagrant.configure("2") do |config|
  config.vm.box = "centos/7"
  config.vm.hostname = "quartztesting"
  config.vm.synced_folder "src/", "/srv/service", type: "virtualbox"
  config.vm.provision "shell", inline: <<-SHELL
    sudo rpm -Uvh https://packages.microsoft.com/config/rhel/7/packages-microsoft-prod.rpm
    sudo yum -y update
    sudo yum -y install dotnet-sdk-2.1
    cd /srv/service/quartz_core
    dotnet publish -c Release
    cp /srv/service/systemd/quartz.service /etc/systemd/system/quartz.service
    sudo systemctl daemon-reload
    sudo systemctl start quartz.service
    sudo systemctl status quartz.service
  SHELL
end
