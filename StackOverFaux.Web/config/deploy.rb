set :application, "Stack Over Mono"
set :repository,  "git://github.com/DataChomp/StackOverMono"

set :scm, :git
# Or: `accurev`, `bzr`, `cvs`, `darcs`, `git`, `mercurial`, `perforce`, `subversion` or `none`

set :deploy_to, "/home/rob/sites/som"
default_run_options[:pty] = true

role :web, "www.stackoverfaux.com"                          # Your HTTP server, Apache/etc
role :app, "www.stackoverfaux.com"                          # This may be the same as your `Web` server
role :db,  "www.stackoverfaux.com", :primary => true # This is where Rails migrations will run


# if you're still using the script/reaper helper you will need
# these http://github.com/rails/irs_process_scripts

# If you are using Passenger mod_rails uncomment this:
namespace :deploy do
  task :start do ; end
  task :stop do ; end
  task :restart, :roles => :app, :web,  :except => { :no_release => true } do
    run "touch App_Code/restart.cs"
    sudo "/etc/init.d/monoserve restart"
  end
end