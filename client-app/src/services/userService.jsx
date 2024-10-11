export const getUser = async (id) => {
  const response = await fetch(`http://localhost:5086/api/user/${id}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  });
  return await response.json();
};
