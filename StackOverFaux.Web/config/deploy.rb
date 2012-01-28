set :application, "StackOverFaux"
set :repository,  "http://github.com/DataChomp/StackOverMono"

set :scm, :git
# Or: `accurev`, `bzr`, `cvs`, `darcs`, `git`, `mercurial`, `perforce`, `subversion` or `none`

role :web, "www.stackoverfaux.com"                          # Your HTTP server, Apache/etc
role :app, "www.stackoverfaux.com"                          # This may be the same as your `Web` server
role :db,  "www.stackoverfaux.com", :primary => true # This is where Rails migrations will run

default_run_options[:pty] = true

set :deploy_to, "/home/rob/sites/datachomp"

# if you're still using the script/reaper helper you will need
# these http://github.com/rails/irs_process_scripts

# If you are using Passenger mod_rails uncomment this:
namespace :deploy do
  task :start do ; end
  task :stop do ; end
  task :restart, :roles => :app, :except => { :no_release => true } do
    run "#{try_sudo} touch #{File.join(current_path,'','Web.config')}"
  end
end