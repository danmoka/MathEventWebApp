import api from "../api";
import { baseService } from "./base-service";

const eventService = {
    fetchEvents: async (eventId) => {
        const url = api.events.fetchEvents(eventId);

        return await baseService.get(url);
    },
    fetchEvent: async (eventId) => {
        const url = api.events.fetchEvent(eventId);

        return await baseService.get(url);
    },
    fetchEventBreadcrumbs: async (eventId) => {
        const url = api.events.fetchEventBreadcrumbs(eventId);

        return await baseService.get(url);
    },
    createEvent: async (createdEvent) => {
        const url = api.events.createEvent();

        return await baseService.post(url, createdEvent);
    },
    updateEvent: async (eventId, updatedEvent) => {
        const url = api.events.updateEvent(eventId);

        return await baseService.put(url, updatedEvent);
    },
    patchEvent: async (eventId, data) => {
        const url = api.events.patchEvent(eventId);

        return await baseService.patch(url, data);
    },
};

export default eventService;