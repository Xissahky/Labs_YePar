import heapq

def calculate_sjf_schedule(tasks):

    tasks.sort(key=lambda x: x[1])

    current_time = 0
    waiting_time = 0
    completed_tasks = []
    task_queue = []
    i = 0
    n = len(tasks)

    while len(completed_tasks) < n:
        while i < n and tasks[i][1] <= current_time:
            heapq.heappush(task_queue, (tasks[i][2], tasks[i]))
            i += 1

        if task_queue:
            execution_time, task = heapq.heappop(task_queue)
            current_time += execution_time
            waiting_time += current_time - task[1] - task[2]
            completed_tasks.append(task[0])
        else:
            current_time += 1

    average_waiting_time = waiting_time / n
    return completed_tasks, average_waiting_time

def read_tasks_from_file(filename):
    tasks = []
    with open(filename, 'r') as file:
        for line in file:
            parts = line.strip().split()
            if len(parts) == 3:
                task_id = parts[0]
                arrival_time = int(parts[1])
                burst_time = int(parts[2])
                tasks.append((task_id, arrival_time, burst_time))
    return tasks

"""
Format pliku: każda linia - id czas_przybycia czas_wykonania
"""
tasks = read_tasks_from_file("list.txt")

schedule, avg_wait_time = calculate_sjf_schedule(tasks)
print("Kolejność wykonania zadań:", schedule)
print("Średni czas oczekiwania:", avg_wait_time)