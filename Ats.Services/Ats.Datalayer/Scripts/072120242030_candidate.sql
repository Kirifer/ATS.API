-- Drop the table if it exists
drop table if exists public.candidates;

  -- Create candidate table
  create table public.candidates (
      id uuid not null,
      job_name text not null,
      client_shortcodes text not null,
      hiring_manager text not null,
      sales_manager text not null,
      hiring_type text not null,
      job_description text not null,
      role_level text not null,
      min_salary int not null,
      max_salary int not null,
      job_location text not null,
      shift_sched text not null,
      job_status text not null,
      open_date date not null default current_date,
      closed_date date not null,
      days_covered int not null,  -- Using int to store the number of days
   
    constraint pk_candidates primary key (id)
  );

-- Create the trigger function
create or replace function update_days_covered()
returns trigger as $$
begin
  new.days_covered := new.closed_date - new.open_date;
  return new;
end;
$$ language plpgsql;

-- Create the trigger
create trigger trg_update_days_covered
before insert or update on public.candidates
for each row
execute procedure update_days_covered();